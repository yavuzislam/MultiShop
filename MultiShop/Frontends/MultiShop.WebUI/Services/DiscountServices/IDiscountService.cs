using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices;

public interface IDiscountService
{
    Task<GetDiscountCodeDetailByCodeDto> GetDiscountCodeDetailByCode(string code);
}
