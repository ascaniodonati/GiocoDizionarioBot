// See https://aka.ms/new-console-template for more information
using GiocoDizionarioBot;
using GiocoDizionarioBot.Handlers;
using GiocoDizionarioBot.Models;
using GiocoDizionarioBot.Settings;

Console.WriteLine("______________________________________");
Console.WriteLine("_                                    _");
Console.WriteLine("_        GIOCO DIZIONARIO BOT        _");
Console.WriteLine("_         by Ascanio Donati          _");
Console.WriteLine("_                                    _");
Console.WriteLine("______________________________________");
Console.WriteLine("");

//Avviamo il bot telegram
Bot.Start();
Console.WriteLine("BOT TELEGRAM AVVIATO");
Console.WriteLine($"Token: {BotSettings.TOKEN_API}");
Console.WriteLine("");

//Inizializzazione del database
Console.WriteLine("DATABASE LOCALE INIZIALIZZATO");
Console.WriteLine($"Stringa di connessione: {DatabaseSettings.ConnectionString}");

using (var db = new GameContext())
{
    Console.WriteLine($"Giocatori presenti: {db.Players.Count()}");
    Console.WriteLine($"Gruppi presenti: {db.Groups.Count()}");
    Console.WriteLine();
}

Console.WriteLine("Premere un tasto per salvare sul database e chiudere il processo");
Console.ReadLine();