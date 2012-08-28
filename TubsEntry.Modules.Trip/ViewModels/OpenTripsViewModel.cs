// -----------------------------------------------------------------------
// <copyright file="OpenTripsViewModel.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.TubsEntry.Modules.Trip.ViewModels
{
    /*
     * This file is part of TUBS.
     *
     * TUBS is free software: you can redistribute it and/or modify
     * it under the terms of the GNU Affero General Public License as published by
     * the Free Software Foundation, either version 3 of the License, or
     * (at your option) any later version.
     *  
     * TUBS is distributed in the hope that it will be useful,
     * but WITHOUT ANY WARRANTY; without even the implied warranty of
     * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
     * GNU Affero General Public License for more details.
     *  
     * You should have received a copy of the GNU Affero General Public License
     * along with TUBS.  If not, see <http://www.gnu.org/licenses/>.
     */
    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.ViewModel;
    using Spc.Ofp.TubsEntry.Modules.Trip.Models;

    /// <summary>
    /// This ViewModel is used to contribute the list of open trips "owned"
    /// by the current user.
    /// </summary>
    public class OpenTripsViewModel : NotificationObject
    {
        public ObservableCollection<TripSummaryItem> OpenTrips { get; private set; }

        // One of the reasons for splitting the ViewModel into 'OpenTrips' and 'ClosedTrips'
        // is that each list has a different set of available commands.
        // For example, editing a closed trip isn't permitted.
        // This command loads a trip for editing.
        public DelegateCommand<TripSummaryItem> LoadTripCommand { get; private set; }

        // This command marks the completion of data entry for the trip.
        public DelegateCommand<TripSummaryItem> FinishTripCommand { get; private set; }

        // This is a scary command.  I'm putting it into the UI, but the 'CanExecute' method
        // will have it disabled until I'm comfortable with it.
        public DelegateCommand<TripSummaryItem> DeleteTripCommand { get; private set; }


        public OpenTripsViewModel()
        {
            // TODO Fill from tubs-data-clr
            OpenTrips = new ObservableCollection<TripSummaryItem>()
            {
                new TripSummaryItem { TripNumber = "ABC / 09-01", DepartureDate = DateTime.Now, ReturnDate = DateTime.Now },
                new TripSummaryItem { TripNumber = "ABC / 09-02", DepartureDate = DateTime.Now, ReturnDate = DateTime.Now },
            };

            LoadTripCommand = new DelegateCommand<TripSummaryItem>(this.LoadTrip, this.CanLoad);
        }

        private TripSummaryItem _selectedTrip;
        public TripSummaryItem SelectedTrip
        {
            get { return _selectedTrip; }
            set
            {
                if (value != _selectedTrip)
                {
                    _selectedTrip = value;
                    this.RaisePropertyChanged(() => this.SelectedTrip);
                }
            }
        }

        private bool CanLoad(TripSummaryItem arg)
        {
            // This is to work around what looks like a bug in WPF.
            // I wasted an entire day trying to get command arguments working from
            // a context menu to no avail.  In the best case, I could get it to work
            // 50-60% of the time.
            arg = arg ?? this.SelectedTrip;
            return null != arg && arg.IsOpen;
        }

        private void LoadTrip(TripSummaryItem arg)
        {
            arg = arg ?? this.SelectedTrip;
            var msg = arg == null ? "LoadTrip got null" : arg.TripNumber;
            MessageBox.Show(msg);
        }
    }
}
