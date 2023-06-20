namespace DonkeyKongGame
{
    /// <summary>
    /// AbstractComponent class, manages a component and interaction with entity.
    /// </summary>
    public abstract class AbstractComponent : IComponent
    {
        //In the Java project, this field is protected because it is visible in all the package.
        //To traduce in C#, I have to set public the field.
        /// <summary>
        /// The entity linked to the component.
        /// </summary>
        public IEntity? Entity { get; set; }

        /// <inheritdoc />
        public abstract void Update();
    }
}
