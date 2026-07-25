namespace E_Commerce.Application.Common
{
    public class Result
    {
        public bool IsSuccess { get; }
        public IReadOnlyList<Error> Errors { get; set; }

        protected Result(bool isSuccess, IReadOnlyList<Error> errors)
        {
            IsSuccess = isSuccess;
            Errors = errors;
        }

        public static Result OK() => new(true, Array.Empty<Error>());
        public static Result Fail(Error error) => new(false, new[] { error });
        public static Result Fail(IReadOnlyList<Error> errors) => new(false, errors);

    }

    public class Result<Tvalue> : Result
    {
        private readonly Tvalue _value;

        public Tvalue data => IsSuccess ? _value : throw new InvalidOperationException("Can Not Access The Value Of Failed Result");

        private Result(Tvalue value):base(true,Array.Empty<Error>())
        {
            _value = value;
        }
        private Result(Error error):base(false,new[] {error})
        {
            _value = default!;
        }
        private Result(IReadOnlyList<Error>errors):base(false,errors)
        {
            _value = default!;
        }


        public static Result<Tvalue> OK(Tvalue value) => new Result<Tvalue>(value);
        public static Result<Tvalue> Fail(Error error) => new Result<Tvalue>(error);
        public static Result<Tvalue> Fail(IReadOnlyList<Error> errors) => new Result<Tvalue>(errors);



        public static implicit operator Result<Tvalue>(Tvalue value) => OK(value);
        public static implicit operator Result<Tvalue>(Error error) => Fail(error);

    }
}
