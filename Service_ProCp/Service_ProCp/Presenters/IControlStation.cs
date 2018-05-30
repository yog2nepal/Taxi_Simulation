using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_ProCp.Views.ControlStation
{
    #region Interface Method
    /// <summary>
    /// An interface for a class responsible for updating the view
    /// </summary>
    public interface IControlStation
    {/// <summary>
     /// Method to update ListViewBox  on ControlStationForm
     /// </summary>
     /// <param name="info">array of datas to be updated on ListViewBox</param>
        void UpdateListBoxViewRealTimeMinutes(string[] info);
        /// <summary>
        /// returns the index of Row which contains certain Car Type
        /// </summary>
        /// <param name="carName"> carType</param>
        /// <returns></returns>
        int FindListViewItemToEdit(string carName);
        /// <summary>
        /// Method to update specific cells at specific index on ListViewBox
        /// </summary>
        /// <param name="index">index at which data is on ListBoxView</param>
        /// <param name="info">data/info to be updated on ListBoxView</param>
        void EditListViewItem(int index, string info);
        /// <summary>
        /// method to update Average Waiting time on Controlstation
        ///  </summary>
        /// <param name="avgTime">average Waiting Time</param>
        void AverageWaitingTime(double avgTime);
    }
    #endregion
}