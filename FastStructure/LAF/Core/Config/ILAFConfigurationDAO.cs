/*
 * Description:This file contains a interface ILAFConfigurationDAO which is used to implement by the child of class.
 * Author: Zhang HeKe
 * Create Date:2007-5-28
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace FastStructure.LAF.Core.Config
{
    /// <summary>
    /// Description:This interface is used to define all method which are must be implemented
    /// Author:Zhang HeKe
    /// Create Date:2007-5-28
    /// </summary>
    public interface ILAFConfigurationDAO
    {
        /// <summary>
        /// Get the obejct of ILAFConfiguration from configuration file
        /// </summary>
        /// <param name="filePath">the full path of configuration file</param>
        /// <returns>the obejct of ILAFConfiguration</returns>
        ILAFConfiguration LoadLAFConfiguration(string filePath);

        /// <summary>
        /// Save the configuration file
        /// </summary>
        /// <param name="lafConfig">the information of LAFConfiguration</param>
        void SaveLAFConfiguration(LAFConfiguration lafConfig);
    }
}
