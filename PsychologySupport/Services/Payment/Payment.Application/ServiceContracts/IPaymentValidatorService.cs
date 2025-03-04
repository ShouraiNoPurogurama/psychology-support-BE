﻿using BuildingBlocks.Enums;
using Payment.Application.Payment.Dtos;

namespace Payment.Application.ServiceContracts;

public interface IPaymentValidatorService
{
    #region Validate Payment Methods

    void ValidateVNPayMethod(PaymentMethodName paymentMethod);
    
    #endregion

    #region Validate Payment Requests

    Task ValidateSubscriptionRequestAsync(BuySubscriptionDto dto);
    Task ValidateBookingRequestAsync(BuySubscriptionDto dto);

    #endregion

    #region Common Validations

    

    #endregion
}