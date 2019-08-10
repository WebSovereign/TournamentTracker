﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class SQLConnector : IDataConnection
    {
        // TODO - Make the CreatePrize method actually save to the database.
        /// <summary>
        /// Saves a new prizes to the database
        /// </summary>
        /// <param name="model">The prize information.</param>
        /// <returns>The prize information, including the unique identifier.</returns>
        public PrizeModel CreatePrize(PrizeModel model)
        {
            model.id = 1;

            return model;
        }
    }
}
