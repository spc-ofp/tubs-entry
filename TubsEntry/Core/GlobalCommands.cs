// -----------------------------------------------------------------------
// <copyright file="GlobalCommands.cs" company="Secretariat of the Pacific Community">
// Copyright (C) 2012 Secretariat of the Pacific Community
// </copyright>
// -----------------------------------------------------------------------

namespace Spc.Ofp.TubsEntry.Core
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
    using System.Windows.Input;

    /// <summary>
    /// Work around a lack of a common exit command in WPF
    /// http://mtaulty.com/CommunityServer/blogs/mike_taultys_blog/archive/2008/11/19/10900.aspx
    /// </summary>
    public static class GlobalCommands
    {
        static GlobalCommands()
        {
            _exitCommand = new RoutedCommand("Exit", typeof(GlobalCommands));
            // TODO Put 'New Trip' in here?
        }

        public static RoutedCommand Exit
        {
            get
            {
                return (_exitCommand);
            }
        }

        static RoutedCommand _exitCommand;
    }
}
