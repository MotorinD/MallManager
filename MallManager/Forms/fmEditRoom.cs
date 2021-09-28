using MallManager.Enums;
using MallManager.Managers;
using System;
using System.Windows.Forms;
using MallManager.DataModels;

namespace MallManager.Forms
{
    /// <summary>
    /// Форма редактирования помещений
    /// </summary>
    public partial class fmEditRoom : Form
    {
        public fmEditRoom()
        {
            this.InitializeComponent();
        }

        public static bool Execute(RoomDataModel dataModel)
        {
            if (dataModel == null)
                return false;

            using (var fm = new fmEditRoom())
            {
                fm.DataModel = dataModel;
                fm.IsAdd = dataModel.Id == 0;
                fm.ShowDialog();
                return fm.DialogResult == DialogResult.OK;
            }
        }

        /// <summary>
        /// Редактируемая модель
        /// </summary>
        public RoomDataModel DataModel { get; set; }

        /// <summary>
        /// Режим редактирования: True если происходит добавление, False если происходит изменение существующей записи
        /// </summary>
        public bool IsAdd { get; set; }

        private void fmEditClassRoom_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadInterface();
                this.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadInterface()
        {
            this.Text = this.IsAdd ? MainResourses.fmEditRoom_AddRoomCaption : MainResourses.fmEditRoom_EditRoomCaption;
            this.cbType.DataSource = Enum.GetValues<RoomTypeEnum>();
        }

        private void LoadData()
        {
            if (this.IsAdd)
                return;

            this.cbType.SelectedIndex = (int)this.DataModel.Type;
            this.tbSquare.Text = this.DataModel.Square.ToString();
            this.tbPrice.Text = this.DataModel.Price.ToString();
            this.tbDescription.Text = this.DataModel.Description;
        }

        private void btnSave_Click(object sender, MouseEventArgs e)
        {
            try
            {
                if (!this.CheckData())
                {
                    this.DialogResult = DialogResult.None;
                    return;
                }

                this.SaveData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool CheckData()
        {
            var res = true;

            res &= ControlValidation.CheckControlTextIsExistAndDecimal(this.tbSquare, this.errorProvider);
            res &= ControlValidation.CheckControlTextIsExistAndDecimal(this.tbPrice, this.errorProvider);

            return res;
        }

        private void SaveData()
        {
            this.DataModel.Type = (RoomTypeEnum)this.cbType.SelectedValue;
            this.DataModel.Square = Convert.ToDecimal(this.tbSquare.Text);
            this.DataModel.Price = Convert.ToDecimal(this.tbPrice.Text);
            this.DataModel.Description = this.tbDescription.Text;

            if (this.IsAdd)
                ManagerHelper.Data.AddRoomDataModel(this.DataModel);
            else
                ManagerHelper.Data.EditRoomDataModel(this.DataModel);
        }
    }
}
