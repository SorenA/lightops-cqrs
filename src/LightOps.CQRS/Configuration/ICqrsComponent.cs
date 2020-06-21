using LightOps.CQRS.Api.Services;

namespace LightOps.CQRS.Configuration
{
    /// <summary>
    /// CQRS dependency injection component
    /// </summary>
    public interface ICqrsComponent
    {
        #region Services
        /// <summary>
        /// Overrides command dispatcher with implementation of type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The type of the implementation</typeparam>
        /// <returns>Returns component for chaining</returns>
        ICqrsComponent OverrideCommandDispatcher<T>() where T : ICommandDispatcher;

        /// <summary>
        /// Overrides query dispatcher with implementation of type <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T">The type of the implementation</typeparam>
        /// <returns>Returns component for chaining</returns>
        ICqrsComponent OverrideQueryDispatcher<T>() where T : IQueryDispatcher;
        #endregion Services
    }
}