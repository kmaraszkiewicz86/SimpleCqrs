﻿namespace SimpleCqrs.ConsoleApp.Demo.Handlers
{
    // Command with int result
    public class SampleCommandWithResult : ICommand<int>
    {
        public int Id { get; set; }
    }
}
