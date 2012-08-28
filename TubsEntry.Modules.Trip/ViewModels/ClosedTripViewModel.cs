// -----------------------------------------------------------------------
// <copyright file="ClosedTripViewModel.cs" company="Secretariat of the Pacific Community">
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
    /// This ViewModel is used to contribute the list of closed trips "owned"
    /// by the current user.
    public class ClosedTripViewModel : NotificationObject
    {
        public ObservableCollection<TripSummaryItem> ClosedTrips { get; private set; }

        // Not common, but re-opening a trip shouldn't require running a SQL query against
        // the database.
        public DelegateCommand<TripSummaryItem> ReopenTripCommand { get; private set; }

        public ClosedTripViewModel()
        {
            // TODO Fill from tubs-data-clr
            ClosedTrips = new ObservableCollection<TripSummaryItem>()
            {
                new TripSummaryItem { TripNumber = "DEF / 09-01", DepartureDate = DateTime.Now, ReturnDate = DateTime.Now },
                new TripSummaryItem { TripNumber = "DEF / 09-02", DepartureDate = DateTime.Now, ReturnDate = DateTime.Now },
            };
            ReopenTripCommand = new DelegateCommand<TripSummaryItem>(this.ReopenTrip, this.CanReopen);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool CanReopen(TripSummaryItem arg)
        {
            arg = arg ?? this.SelectedTrip;
            return null != arg && !arg.IsOpen;
        }

        /// <summary>
        /// Reopen the selected trip.
        /// TODO:  Add "confirm" step via standard Prism mechanism
        /// </summary>
        /// <param name="arg"></param>
        private void ReopenTrip(TripSummaryItem arg)
        {
            arg = arg ?? this.SelectedTrip;
            var msg = arg == null ? "ReopenTrip got null" : arg.TripNumber;
            MessageBox.Show(msg);
        }
    }
}
