using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class BusinessEntity
    {
        public enum States { Deleted, New, Modified, Unmodified }

        #region CAMPOS
        private int _id;
        private States _state;
        #endregion

        #region PROPIEDADES
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

        #endregion

        public BusinessEntity()
        {
            this.State = States.New;
        }

    }
}
