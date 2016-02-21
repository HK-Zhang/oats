/*
 * Description:This file contains a class LAFConfigurationDAOFacotry to maintain the instance of LAFConfigurationDAO.
 * Author: Zhang HeKe
 * Create Date:2007-5-30
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Core.Config
{
    /// <summary>
    /// Description:This class is used to maintain the instance of LAFConfigurationDAO
    /// Author:Zhang HeKe
    /// Create Date:2007-5-30
    /// </summary>
    public class LAFConfigurationDAOFacotry
    {
        /// <summary>
        /// Get the object of ILAFConfigurationDAO
        /// </summary>
        /// <returns>A instance of ILAFConfigurationDAO</returns>
        public static ILAFConfigurationDAO GetLAFConfigurationDAO()
        {
            return new LAFConfigurationDAO();
        }
    }
}
