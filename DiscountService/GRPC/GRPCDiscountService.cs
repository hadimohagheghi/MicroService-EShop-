using DiscountService.Model.Services;
using DiscountService.Proto;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscountService.Model.Services.Interface;

namespace DiscountService.GRPC
{
    public class GRPCDiscountService : DiscountServiceProto.DiscountServiceProtoBase
    {
        private readonly IDiscountService discountService;

        public GRPCDiscountService(IDiscountService discountService)
        {
            this.discountService = discountService;
        }
        public override Task<ResultGetDiscount> GetDiscountByCode(RequestGetDiscountByCode request, ServerCallContext context)
        {
            var data = discountService.GetDiscountByCode(request.Code);
            if (data==null)
            {
                return Task.FromResult(new ResultGetDiscount
                {
                    IsSuccess = false,
                    Message = "کد تخفیف وارد شده یافت نشد",
                    Data = null
                });
            }
            return Task.FromResult(new ResultGetDiscount
            {
                IsSuccess = true,
                Message = "",
                Data = new DiscountInfo
                {
                    Amount = data.Amount,
                    Code = data.Code,
                    Id = data.Id.ToString(),
                    Used = data.Used,
                }
                
        
            });
        }


        public override Task<ResultGetDiscount> GetDiscountById(RequestGetDiscountById request, ServerCallContext context)
        {
            var data = discountService.GetDiscountById(Guid.Parse(request.Id));
            if (data == null)
            {
                return Task.FromResult(new ResultGetDiscount
                {
                    IsSuccess = false,
                    Message = "کد تخفیف وارد شده یافت نشد",
                    Data = null
                });
            }
            return Task.FromResult(new ResultGetDiscount
            {
                IsSuccess = true,
                Message = "",
                Data = new DiscountInfo
                {
                    Amount = data.Amount,
                    Code = data.Code,
                    Id = data.Id.ToString(),
                    Used = data.Used,
                }


            });

        }

        public override Task<ResultUseDiscount> UseDiscount(RequestUseDiscount request, ServerCallContext context)
        {
            var result = discountService.UseDiscount(Guid.Parse(request.Id));
            return Task.FromResult(new ResultUseDiscount
            {
                IsSuccess = result,
            });
        }

        public override Task<ResultAddNewDiscount> AddNewDiscount(RequestAddNewDiscount request, ServerCallContext context)
        {
            var result = discountService.AddNewDiscount(request.Code, request.Amount);
            return Task.FromResult(new ResultAddNewDiscount
            {
                IsSuccess = result,
            });
        }
    }
}