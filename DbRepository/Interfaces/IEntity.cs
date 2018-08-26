using System;
using System.Collections.Generic;
using System.Text;

namespace DbRepository.Interfaces
{
    public interface IEntity
    {
        int ID { get; set; }

        DateTime CreatedDate { get; set; }
    }
}
