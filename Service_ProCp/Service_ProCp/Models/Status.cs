namespace Service_ProCp.Models
{

    public enum Status
    {
        #region Status
        /// <summary>
        /// Initial status of the Car
        /// </summary>
        IdleAtHotSpot = -1,
        /// <summary>
        /// Used for Status update of the Car
        /// </summary>
        GoingToPickPassenger = 0,
        /// <summary>
        /// Used for Status update of the Car
        /// </summary>
        PickedPassenger = 1,
        /// <summary>
        /// Used for Status update of the Car
        /// </summary>
        DroppedPassenger = 2
        #endregion
    }
}