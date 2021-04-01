using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICreditNoteService
    {
        IDataResult<List<CreditNote>> GetAll();
        IDataResult<CreditNote> GetById(int id);
        IDataResult<CreditNote> GetUserById(int userId);
        IDataResult<CreditNote> Add(CreditNote creditNote);

    }
}
