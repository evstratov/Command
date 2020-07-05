using System;

namespace Command
{
    interface ICommand
    {
        void Execute();
    }
    // команда , делегирующая вызов получателю
    class SaveCommand : ICommand
    {
        FileSystem fs;
        string file;
        public SaveCommand(FileSystem fs, string file)
        {
            this.fs = fs;
            this.file = file;
        }
        public void Execute()
        {
            fs.SaveFile(file);
        }
    }
    // простая команда
    class SoundCommand : ICommand
    {
        string sound;
        public SoundCommand(string sound)
        {
            this.sound = sound;
        }
        public void Execute()
        {
            Console.WriteLine("Проигрываю звук " + sound);
        }
    }

    // получатель
    class FileSystem
    {
        public void SaveFile(string file)
        {
            Console.WriteLine("Сохраняю файл " + file);
        }
    }
    // отправитель
    class Button
    {
        ICommand command;
        public Button(ICommand command)
        {
            this.command = command;
        }
        public void Push()
        {
            command.Execute();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FileSystem fs = new FileSystem();

            ICommand saveCommand = new SaveCommand(fs, "text.txt");
            ICommand soundCommand = new SoundCommand("click click");

            Button saveButton = new Button(saveCommand);
            Button soundButton = new Button(soundCommand);

            saveButton.Push();
            soundButton.Push();

            Console.Read();
        }
    }
}
