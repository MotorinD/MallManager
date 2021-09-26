using AutoMapper;
using MallManager.DAL.Entities;
using MallManager.Forms;
using MallManager.Managers;
using MallManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MallManager
{
    public partial class fmMain : Form
    {
        private Mapper _mapper => ManagerHelper.Mapper.GetActive();
        public fmMain()
        {
            this.InitializeComponent();
        }

        private void fmMain_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadInterface();
                this.RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshData()
        {
            this.SaveGridVievState();
            this.GetDataAndSetToGridDataSource();
            this.RestoreGridViewState();
        }

        private void GetDataAndSetToGridDataSource()
        {
            var dataList = ManagerHelper.Data.GetRoomDataModelList();
            var viewModelList = this._mapper.Map<List<RoomViewModel>>(dataList);
            this.gvRoom.DataSource = viewModelList;
        }

        #region Scroll and Select row position Save and Restore

        private int _firstVisibleRowIndex = 0;
        private int _selectedRowIndex = 0;

        /// <summary>
        /// Сохранить положение прокрутки и выбранную строку таблицы
        /// </summary>
        private void SaveGridVievState()
        {
            this._firstVisibleRowIndex = this.gvRoom.FirstDisplayedScrollingRowIndex;
            this._selectedRowIndex = this.gvRoom.CurrentRow?.Index ?? 0;
        }

        /// <summary>
        /// Восстановить положение прокрутки и выбранную строку таблицы
        /// </summary>
        private void RestoreGridViewState()
        {
            this.gvRoom.ClearSelection();

            if (this.gvRoom.Rows.Count > 0)
                if (this.gvRoom.Rows.Count > this._selectedRowIndex)
                {
                    this.gvRoom.Rows[this._selectedRowIndex].Selected = true;
                    this.gvRoom.CurrentCell = this.gvRoom[0, this._selectedRowIndex];
                }
                else
                {
                    this.gvRoom.Rows[this.gvRoom.Rows.Count - 1].Selected = true;
                    this.gvRoom.CurrentCell = this.gvRoom[0, this.gvRoom.Rows.Count - 1];
                }

            if (this._firstVisibleRowIndex > 0)
                this.gvRoom.FirstDisplayedScrollingRowIndex = this._firstVisibleRowIndex;
        }

        #endregion

        private void LoadInterface()
        {
            this.gvRoom.AutoGenerateColumns = false;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (fmEditRoom.Execute(new Room()))
                    this.RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gvRoom.CurrentRow == null)
                    return;

                var selectedItem = this.gvRoom.CurrentRow.DataBoundItem as RoomViewModel;

                if (selectedItem == null)
                    return;

                if (fmEditRoom.Execute(selectedItem.DataModel))
                    this.RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.gvRoom.CurrentRow == null)
                    return;

                var selectedItem = this.gvRoom.CurrentRow.DataBoundItem as RoomViewModel;

                if (selectedItem == null)
                    return;

                var deleteDialogResult = MessageBox.Show(MainResourses.fmMain_ShureDeleteRoomQuestion, MainResourses.fmMain_WarningCaption, MessageBoxButtons.YesNo);

                if (deleteDialogResult == DialogResult.Yes)
                {
                    ManagerHelper.Entity.Room.Delete(selectedItem.DataModel.Id);
                    this.RefreshData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
