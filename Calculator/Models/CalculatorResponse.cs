﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace Calculator.Models
{
    public class CalculatorResponse
    {
        public int Output { get; set; }
    }
}