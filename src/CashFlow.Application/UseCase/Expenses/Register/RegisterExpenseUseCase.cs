using CashFlow.Communication.Enums;
using CashFlow.Communication.Request;
using CashFlow.Communication.Response;

namespace CashFlow.Application.UseCase.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseRegisterExpenseJson Execute(RequestRegisterExpenseJson request)
    {
       
        Validate(request);
        return new ResponseRegisterExpenseJson();
    }
    private void Validate(RequestRegisterExpenseJson request) 
    {
        var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
        
        if (titleIsEmpty)
        {
            throw new Exception("Title is required");
        }

        if(request.Amount <= 0)
        {
            throw new Exception("Amount must be greater than 0");
        }
        if(DateTime.Compare(request.Date, DateTime.UtcNow) > 0)
        {
            throw new Exception("Date must be less than or equal to the current date");
        }
       if( Enum.IsDefined(typeof(PaymentType),request.paymentType) == false)
        {
            throw new Exception("Payment type is invalid");
        }
      
        
    }
}
