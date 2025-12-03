using System;
using System.Collections.Generic;
using System.Text;
using UmbracoSystem.Models;

namespace UmbracoSystem.ViewModels
{
    public class AltWorkTypeController
    {
        public List<AltWorkType> GetAllAltWorkTypes()
        {
            List<AltWorkType> result = AltWorkTypeRepository.GetAll();

            return result;
        }
    }
}
