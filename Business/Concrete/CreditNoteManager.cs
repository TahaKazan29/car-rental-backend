using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CreditNoteManager:ICreditNoteService
    {
        private ICreditNoteDal _creditNoteDal;

        public CreditNoteManager(ICreditNoteDal creditNoteDal)
        {
            _creditNoteDal = creditNoteDal;
        }

        public IDataResult<List<CreditNote>> GetAll()
        {
            return new SuccessDataResult<List<CreditNote>>(_creditNoteDal.GetAll());
        }

        public IDataResult<CreditNote> GetById(int id)
        {
            return new SuccessDataResult<CreditNote>(_creditNoteDal.Get(c => c.Id == id));
        }

        public IDataResult<CreditNote> GetUserById(int userId)
        {
            return new SuccessDataResult<CreditNote>(_creditNoteDal.Get(c => c.UserId == userId));
        }

        public IDataResult<CreditNote> Add(CreditNote creditNote)
        {
            Random value = new Random();
            creditNote.FindeksValue = value.Next(0, 1901);
            _creditNoteDal.Add(creditNote);
            return new SuccessDataResult<CreditNote>(creditNote,Messages.Completed);
        }
    }
}
