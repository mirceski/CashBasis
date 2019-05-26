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
            var orderedBills = await allBills.OrderBy(c => c.DueDate)
                                        .Skip((pageNumber - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToListAsync();

            return _mapper.Map<List<BillDto>>(orderedBills);
        }

        public BillDto GetBillById(int id)
        {
            var existingBill = _unitOfWork.BillRepository.FindById(id);
            return _mapper.Map<BillDto>(existingBill);
        }

        public async Task<BillDto> CreateBill(BillDto item)
        {
            var entityBill = _mapper.Map<Bill>(item);
            
            var newBillItem = _unitOfWork.BillRepository.Add(entityBill);
            await _unitOfWork.CommitAsync();
            
            if (item.BillItems != null && item.BillItems.Any())
            {
                foreach (var billItem in item.BillItems)
                {
                    var billItemEntity = _mapper.Map<BillItem>(billItem);
                    _unitOfWork.BillItemRepository.Add(billItemEntity);
                    await _unitOfWork.CommitAsync();
                }
            }
            return _mapper.Map<BillDto>(newBillItem);
        }

        public async Task<BillDto> UpdateBill(int id, BillDto item)
        {
            var entityBill = _mapper.Map<Bill>(item);
            var existingBill = _unitOfWork.BillRepository.GetBillWithRelatedEntitiesById(item.BillId);
            
            if (existingBill != null)
            {
                var newBill = _unitOfWork.BillRepository.Update(id, entityBill);
                
                foreach (var billItem in existingBill.BillItems.ToList())
                {
                    if (!item.BillItems.Any(x => x.BillItemId == billItem.BillItemId))
                    {
                        _unitOfWork.BillItemRepository.Delete(billItem.BillItemId);
                    }
                }

                foreach (var billItem in item.BillItems)
                {
                    var existingBillItem = existingBill.BillItems
                        .Where(x => x.BillItemId == billItem.BillItemId).SingleOrDefault();

                    var entityBillItem = _mapper.Map<BillItem>(billItem);

                    if (existingBillItem != null)
                    {
                        _unitOfWork.BillItemRepository.Update(existingBillItem.BillItemId, entityBillItem);
                    }
                    else
                    {
                        _unitOfWork.BillItemRepository.Add(entityBillItem);
                    }
                }

                await _unitOfWork.CommitAsync();
                return _mapper.Map<BillDto>(newBill);
            }
            else
            {
                return await CreateBill(item);
            }
            
        }

        public void RemoveBill(int id)
        {
            _unitOfWork.BillRepository.Delete(id);
            _unitOfWork.Commit();
        }
    }
}
