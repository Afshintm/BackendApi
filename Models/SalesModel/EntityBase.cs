using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;

namespace SalesModel
{
    public abstract class EntityBase: IObjectState
    {
        public int Id { get; set; }
        public string Name { get; set; }
	    public ObjectState ObjectState { get; set; }

	    public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}", Id, Name);
        }
    }
}