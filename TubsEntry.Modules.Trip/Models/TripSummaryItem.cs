// -----------------------------------------------------------------------
// <copyright file="TripSummaryItem.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.TubsEntry.Modules.Trip.Models
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

    /// <summary>
    /// TripSummaryItem is a limited view of a trip.
    /// This is just enough data to show in a simple list.
    /// </summary>
    public sealed class TripSummaryItem
    {
        public int TripId { get; set; }

        public string TripNumber { get; set; }

        public string ProgramCode { get; set; }

        public string VesselName { get; set; }

        public DateTime? DepartureDate { get; set; }

        public string DeparturePort { get; set; }

        public DateTime? ReturnDate { get; set; }

        public string ReturnPort { get; set; }

        public bool IsOpen { get; set; }
    }
}
