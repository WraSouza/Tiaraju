﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiaraju.FirebaseServices.Services.Implementations;
using Tiaraju.Helpers;
using Tiaraju.Models;

namespace Tiaraju.ViewModels
{
    partial class AdicionarAtividadeViewModel : ObservableObject
    {
        ProjectServices projectServices = new();
        DepartmentServices departmentServices = new();
        ActivityServices activityServices = new();

        public ObservableCollection<Project> Projects { get; set; } = new ObservableCollection<Project>();
        public ObservableCollection<Department> Departments { get; set; } = new ObservableCollection<Department>();

        List<string> setoresEnvolvidos = new List<string>();
        List<string> setorResponsavel = new List<string>();

        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public Project project;

        [ObservableProperty]
        public DateTime finalDate;

        [ObservableProperty]
        public string priority;

        [ObservableProperty]
        public string status;

        [ObservableProperty]
        public Department setores;

        [ObservableProperty]
        public Department ownerdepartment;

        public AdicionarAtividadeViewModel()
        {
            BuscaProjetos();
            BuscaDepartamentos();
        }

        [RelayCommand]
        public async void AddActivity()
        {
            bool verificaConexao = Conectividade.VerificaConectividade();

            if (verificaConexao)
            {
                if (finalDate < DateTime.Now)
                {
                    Mensagem.MensagemDataDeveSerMaior();

                    return;
                }


                if (string.IsNullOrEmpty(Title))
                {
                    Mensagem.MensagemObrigatoriedadeCredenciais();

                    return;
                }

                //Verifica se a atividade existe. Se existir, traz as informações dela para que seja atualizada
                bool verificaSeAtividadeExiste = await activityServices.ActivityExist(Title, Project.Name);

                if (verificaSeAtividadeExiste)
                {
                    var listadoBanco = await activityServices.GetAtividade(Title);

                    foreach(var item in listadoBanco)
                    {
                        setoresEnvolvidos.Add(Setores.DepartmentAcronym);

                        //setorResponsavel.Add(ownerdepartment.DepartmentAcronym);
                    }                    

                    var atualizarAtividade = new Atividade(Project.Name, Title, finalDate.ToShortDateString(), Priority, Status, setorResponsavel, setoresEnvolvidos);

                    activityServices.UpdateActivity(atualizarAtividade);


                    //TODO atualizar o projeto. Ver a necessidade de atualizar o projeto
                    return;
                }


                //Aqui adiciona uma nova atividade.
                setoresEnvolvidos.Add(Setores.DepartmentAcronym);

                setorResponsavel.Add(ownerdepartment.DepartmentAcronym);

                var atividade = new Atividade(Project.Name, Title, finalDate.ToShortDateString(), Priority, Status, setorResponsavel, setoresEnvolvidos);
                
                await activityServices.AddActivity(atividade);

                Mensagem.MensagemCadastroSucesso();
                
                return;
            }

            Mensagem.MensagemErroConexao();
        }

        async void BuscaDepartamentos()
        {
            bool verificaConexao = Conectividade.VerificaConectividade();

            if(verificaConexao )
            {
                var setores = await departmentServices.GetDepartments();

                foreach(var department  in setores)
                {
                    Departments.Add(department);
                }
                return;
            }

            Mensagem.MensagemErroConexao();
        }
        async void BuscaProjetos()
        {
            bool verificaConexao = Conectividade.VerificaConectividade();

            if(verificaConexao)
            {
                var projects = await projectServices.GetProjects();

                foreach (var project in projects)
                {
                    Projects.Add(project);
                }

                return;
            }

            Mensagem.MensagemErroConexao();
        }
    }
}