using MallManager.Additional;
using MallManager.DAL;
using MallManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MallManager.Forms
{
    public partial class fmEditRoom : Form
    {
        public fmEditRoom()
        {
            this.InitializeComponent();
        }

        public Room DataModel { get; set; }

        public bool IsAdd { get; set; }

        public EntityManager Em { get { return EntityManager.Active; } }

        public List<Room> ClassRoomList { get; set; }

        public static bool Execute(Room dataModel)
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

        private void fmEditClassRoom_Load(object sender, EventArgs e)
        {
            this.LoadInterface();
            this.LoadData();
        }

        private void LoadInterface()
        {
            this.Text = this.IsAdd ? "Добавление помещения" : "Редактирование помещения";
        }

        private void LoadData()
        {
            this.cbType.DataSource = Extensions.GetEnumValuesAndDescriptions<RoomTypeEnum>();
            this.ClassRoomList = this.Em.Room.GetList();

            if (!this.IsAdd)
            {
                this.cbType.SelectedIndex = this.DataModel.Type;
                this.tbSquare.Text = this.DataModel.Square.ToString();
                this.tbPrice.Text = this.DataModel.Price.ToString();
                this.tbDescription.Text = this.DataModel.Description;
            }
        }

        private bool CheckData()
        {
            var res = true;

            if (string.IsNullOrWhiteSpace(this.tbSquare.Text))
            {
                this.errorProvider.SetError(this.tbSquare, "Введите значение");
                res = false;
            }
            else
            {
                var num = 0m;
                if (!Decimal.TryParse(this.tbSquare.Text, out num))
                {
                    this.errorProvider.SetError(this.tbSquare, "Значение должно быть числом");
                    res = false;
                }
            }

            if (string.IsNullOrWhiteSpace(this.tbPrice.Text))
            {
                this.errorProvider.SetError(this.tbPrice, "Введите значение");
                res = false;
            }
            else
            {
                var num = 0m;
                if (!Decimal.TryParse(this.tbPrice.Text, out num))
                {
                    this.errorProvider.SetError(this.tbPrice, "Значение должно быть числом");
                    res = false;
                }
            }

            return res;
        }

        private void SaveData()
        {
            this.DataModel.Type = this.cbType.SelectedIndex;
            this.DataModel.Square = Convert.ToDecimal(this.tbSquare.Text);
            this.DataModel.Price = Convert.ToDecimal(this.tbPrice.Text);
            this.DataModel.Description = this.tbDescription.Text;

            if (this.IsAdd)
                this.Em.Room.Add(this.DataModel);
            else
                this.Em.Room.Edit(this.DataModel);
        }

        private void btnSave_Click(object sender, MouseEventArgs e)
        {
            if (!this.CheckData())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }

            this.SaveData();
        }
    }
}
