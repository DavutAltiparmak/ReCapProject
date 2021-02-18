using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId);

            foreach (var r in result)
            {
                if (r != null && r.ReturnDate==null)
                {
                    return new ErrorResult(Messages.CarNotDelivered);
                }
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IResult Return(Rental rental)
        {
            var rentalToUpdate = new Rental
            {
                Id = rental.Id, 
                CarId = rental.CarId, 
                CustomerId = rental.CustomerId, 
                RentDate = rental.RentDate,
                ReturnDate = DateTime.Now
            };

            if (rental.ReturnDate != null)
            {
                return new ErrorResult("Zaten teslim edilmiş");
            }

            _rentalDal.Update(rentalToUpdate);

            return new SuccessResult();
        }
    }
}
