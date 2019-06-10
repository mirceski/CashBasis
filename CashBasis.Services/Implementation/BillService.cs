using AutoMapper;
using CashBasis.BusinessModel.Dtos;
using CashBasis.DAL.Interfaces;
using CashBasis.Entities;
using CashBasis.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashBasis.Services.Implementation
{
    public class BillService : IBillService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BillService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<BillDto>> GetAllBills(int pageNumber, int pageSize = 15)
        {
            var allBills = _unitOfWork.BillRepository.GetAllBillsWithRelatedEntities();
            var sortedBills = await allBills.OrderBy(c => c.DueDate)
                                        .Skip((pageNumber - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();

            return _mapper.Map<List<BillDto>>(sortedBills);
        }

        public BillDto GetBillById(int id)
        {
            var existingBill = _unitOfWork.BillRepository.GetBillWithRelatedEntitiesById(id);
            return _mapper.Map<BillDto>(existingBill);
        }

        public BillCreateUpdateDto CreateBill(BillCreateUpdateDto item)
        {
            var entityBill = _mapper.Map<Bill>(item);
            
            var newBillItem = _unitOfWork.BillRepository.Add(entityBill);
            _unitOfWork.Commit();
            
            return _mapper.Map<BillCreateUpdateDto>(newBillItem);
        }

        public BillItemsDto CreateBillItem(BillItemsDto item)
        {
            var entityBillItem = _mapper.Map<BillItem>(item);
            
            var newBillItem = _unitOfWork.BillItemRepository.Add(entityBillItem);
            _unitOfWork.Commit();

            return _mapper.Map<BillItemsDto>(newBillItem);
        }

        public BillItemsDto UpdateBillItem(int billItemId, BillItemsDto item)
        {
            var entityBillItem = _mapper.Map<BillItem>(item);

            var existingBillItem = _unitOfWork.BillItemRepository.FindById(billItemId);

            BillItemsDto updatedBillItem = null;
            if (existingBillItem != null)
            {
                _unitOfWork.BillItemRepository.Update(billItemId, entityBillItem);
                _unitOfWork.Commit();
                return _mapper.Map<BillItemsDto>(updatedBillItem);
            }
            return null;
        }

        public BillCreateUpdateDto UpdateBill(int id, BillCreateUpdateDto item)
        {
            var entityBill = _mapper.Map<Bill>(item);

            entityBill.BillId = id;
            var updatedBill = _unitOfWork.BillRepository.Update(id, entityBill);
            _unitOfWork.Commit();

            return _mapper.Map<BillCreateUpdateDto>(updatedBill);
        }

        public void RemoveBill(int id)
        {
            _unitOfWork.BillRepository.Delete(id);
            _unitOfWork.Commit();
        }
    }
}
