﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Application.Services.Institution;

public interface IInstitutionService
{
    Task<int> ImportAllInstitutionsAsync(string importedBy);
}
