﻿using Biosfera3.Models;
using Biosfera3.Repository;

namespace Biosfera3.Service
{
    public class SensorService
    {
        public Sensor _sensor { get; set; }
        public Pesquisador _pesquisador { get; set; }

        public SensorService(Sensor sensor, Pesquisador pesquisador)
        {
            _sensor = sensor;
            _pesquisador = pesquisador;
        }
        private IVerificaParametros _param;
        public SensorService(IVerificaParametros param)
        {
            _param = param;
        }

        public void VerificaTemperatura(string local)
        {
            var pesquisador = _pesquisador.Nome;
            Console.WriteLine($"Pesquisador:: {pesquisador}");

            var get = _param.GetParametros(local);
            

            var temperaturaAtual = _sensor.temperatura;
            if (temperaturaAtual < 10)
            {
                Console.WriteLine($"Cuidado a temperatura do {local} está baixa!");
                Console.WriteLine($"Temperatura Atual:: {temperaturaAtual} ºC");
            }
            if (temperaturaAtual < 20)
            {
                Console.WriteLine($"Cuidado a temperatura do {local} está ficando baixa!");
                Console.WriteLine($"Temperatura Atual:: {temperaturaAtual} ºC");
            }
            if (temperaturaAtual > 30.0 && temperaturaAtual <= 40.0)
            {
                Console.WriteLine($"Cuidado a temperatura do {local} está alta!");
                Console.WriteLine($"Temperatura Atual:: {temperaturaAtual} ºC");
            }
            if (temperaturaAtual > 40.0 && temperaturaAtual <= 50.0)
            {
                Console.WriteLine($"Cuidado a temperatura do {local} está muito alta!");
                Console.WriteLine($"Temperatura Atual:: {temperaturaAtual} ºC");
            }
            if (temperaturaAtual > 50.0)
            {
                Console.WriteLine($"ALERTA!! ALERTA!! O {local} deve ser evacuado imediatamente. A temperatura está extremamente alta!");
                Console.WriteLine($"Temperatura Atual:: {temperaturaAtual} ºC");
            }
            else
            {
                Console.WriteLine($"A temperatura do {local} está adequada.");
                Console.WriteLine($"Temperatura Atual:: {temperaturaAtual} ºC");
            }
        }

        public void VerificaUmidade(string local)
        {
            var pesquisador = _pesquisador.Nome;
            Console.WriteLine($"Pesquisador:: {pesquisador}");

            var umidadeAtual = _sensor.umidade;
            if (umidadeAtual <= 10)
            {
                Console.WriteLine($"Cuidado! A umidade do {local} está muito baixa!");
                Console.WriteLine($"Umidade Atual:: {umidadeAtual} %");
            }
            if (umidadeAtual <= 20)
            {
                Console.WriteLine($"A umidade do {local} está baixa!");
                Console.WriteLine($"Umidade Atual:: {umidadeAtual} %");
            }
            if (umidadeAtual > 20 && umidadeAtual < 100)
            {
                Console.WriteLine($"A umidade do {local} está adequada.");
                Console.WriteLine($"Umidade Atual:: {umidadeAtual} %");
            }
        }

        public void VerificaGasCarbonico(string local)
        {
            var pesquisador = _pesquisador.Nome;
            Console.WriteLine($"Pesquisador:: {pesquisador}");

            var gasCarbonicoAtual = _sensor.gasCarbonico;
            if (gasCarbonicoAtual >= 800 && gasCarbonicoAtual <= 999)
            {
                Console.WriteLine($"Cuidado! O gás carbonico do {local} está alto!");
                Console.WriteLine($"Gás Carbonico Atual:: {gasCarbonicoAtual} ppm");
            }
            if (gasCarbonicoAtual >= 1000)
            {
                Console.WriteLine($"ALERTA!! ALERTA!! O {local} deve ser evacuado imediatamente. O gás carbônico está em quantidades inaceitáveis para o ser humano!");
                Console.WriteLine($"Gás Carbonico Atual:: {gasCarbonicoAtual} ppm");
            }
            else
            {
                Console.WriteLine($"Gás carbonico do {local} está em quantidades adequadas.");
                Console.WriteLine($"Gás Carbonico Atual:: {gasCarbonicoAtual} ppm");
            }
        }
    }
}
