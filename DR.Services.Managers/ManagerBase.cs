using DR.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DR.Services.Managers
{ 
    /// <summary>
    /// Base class for all service managers
    /// </summary>
    public class ManagerBase
    {
        public ManagerBase()
        {
            OperationContext operationContext = OperationContext.Current;
            if(operationContext != null)
            {
                //Get bring the incoming message headers
                _loginUserName = operationContext.IncomingMessageHeaders.GetHeader<string>("String", "System");

                //Desktop application user check
                if (_loginUserName.IndexOf(@"\") > 1) _loginUserName = string.Empty;
            }

            if(!string.IsNullOrWhiteSpace(_loginUserName))
            {
                _loggedInUser = LoadLoggedUser(_loginUserName);
            }
        }

        protected User _loggedInUser = null; 
        private string _loginUserName;


        protected virtual User LoadLoggedUser(string userName)
        {
            return null;
        }

        protected void  ValidateUser(string userName)
        {
            if( _loggedInUser !=null)
            {
                if (_loginUserName != string.Empty && _loginUserName != userName)
                {
                    //TODO:Custom exception for authorization
                    throw new FaultException($"User { userName  } not authorized for this action");
                }
            }
        }
        protected T ExecuteFaultHandledOperation<T>(Func<T> codeToExecute)
        {
            try
            {
                return codeToExecute.Invoke();
            }
            catch (FaultException ex)
            {
                //Rethrow FaultException
                throw ex;
            }
            catch (Exception ex)
            {

                throw new FaultException(ex.Message);
            }
        }

        protected void ExecuteFaultHandledOperation(Action codeToExecute)
        {
            try
            {
                 codeToExecute.Invoke();
            }
            catch (FaultException ex)
            {
                //Rethrow FaultException
                throw ex;
            }
            catch (Exception ex)
            {

                throw new FaultException(ex.Message);
            }
        }
    }
}
