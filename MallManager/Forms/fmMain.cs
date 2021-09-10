using MallManager.DAL;
using MallManager.DAL.Entities;
using MallManager.Forms;
using MallManager.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MallManager
{
    public partial class fmMain : Form
    {
        public fmMain()
        {
            this.InitializeComponent();
        }

        public EntityManager Em { get { return EntityManager.Active; } }

        private void fmMain_Load(object sender, EventArgs e)
        {
            EntityManager.InitEntityManager();
            this.LoadInterface();
            this.RefreshData();
            this.gvRoom.DataSource = this.Em.Room.GetList().Select(o => new RoomViewModel(o)).ToList();
        }

        private void RefreshData()
        {
            try
            {
                var curIndex = 0;

                if (this.gvRoom.CurrentRow != null)
                {
                    curIndex = this.gvRoom.CurrentRow.Index;
                    this.gvRoom.CurrentRow.Selected = false;
                }

                var dataSource = this.Em.Room.GetList().Select(o => new RoomViewModel(o)).ToList();

                this.gvRoom.DataSource = dataSource;
                this.gvRoom.ClearSelection();

                foreach (DataGridViewRow row in this.gvRoom.Rows)
                {
                    var item = row.DataBoundItem as RoomViewModel;
                }

                if (this.gvRoom.Rows.Count > 0)
                    if (this.gvRoom.Rows.Count > curIndex)
                    {
                        this.gvRoom.Rows[curIndex].Selected = true;
                        this.gvRoom.CurrentCell = this.gvRoom[0, curIndex];
                    }
                    else
                    {
                        this.gvRoom.Rows[this.gvRoom.Rows.Count - 1].Selected = true;
                        this.gvRoom.CurrentCell = this.gvRoom[0, this.gvRoom.Rows.Count - 1];
                    }
            }
            catch
            {
                var dataSource = this.Em.Room.GetList().Select(o => new RoomViewModel(o)).ToList();
                this.gvRoom.DataSource = dataSource;
            }
        }

        private void LoadInterface()
        {
            this.gvRoom.AutoGenerateColumns = false;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (fmEditRoom.Execute(new Room()))
                this.RefreshData();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (this.gvRoom.CurrentRow == null)
                return;

            var selectedItem = this.gvRoom.CurrentRow.DataBoundItem as RoomViewModel;

            if (selectedItem == null)
                return;

            if (fmEditRoom.Execute(selectedItem.DataModel))
                this.RefreshData();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (this.gvRoom.CurrentRow == null)
                return;

            var selectedItem = this.gvRoom.CurrentRow.DataBoundItem as RoomViewModel;

            if (selectedItem == null)
                return;

            var deleteDialogResult = MessageBox.Show("Удалить выбранное помещение?", "Внимание", MessageBoxButtons.YesNo);

            if (deleteDialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                this.Em.Room.Delete(selectedItem.DataModel.Id);
                this.RefreshData();
            }
        }
    }
}
