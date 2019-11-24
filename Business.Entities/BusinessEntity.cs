using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    class BusinessEntity
    {
        public enum States { Deleted, New, Modified, Unmodified }

        private int _id;
        private States _state;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public States State
        {
            get { return _state; }
            set { _state = value; }
        }

        public BusinessEntity()
        {
            this.State = States.New;
        }



    }
}
