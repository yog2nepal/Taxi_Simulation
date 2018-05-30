using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_ProCp.Models
{

    public enum OrderStatus
    {
        // Enuma for the car order status
        #region OrderStatus
        /// <summary>
        /// Order status of car on movement to pick passenger
        /// </summary>
        Proceed,
        /// <summary>
        /// Order cancelled before picked passenger
        /// </summary>
        Cancel,
        /// <summary>
        /// Order change when picked up passenger
        /// </summary>
        Change,
        /// <summary>
        /// Order cancelling before picking passenger
        /// </summary>
        CancelBeforePicking
        #endregion
    }

}
