(function () {
    'use strict';

    angular
        .module('app')
        .config(['$translateProvider', function ($translateProvider) {
            $translateProvider.translations('en', getEnglishTranslations());
            $translateProvider.translations('fr', getFrenchTranslations());
            $translateProvider.preferredLanguage('fr');
        }]);;

    function getEnglishTranslations() {
        return {
            ApplicationTitle: "IEJP Time management",
            ForgotYourPassword: "Forgot your password?",
            Login: "Log in",
            RegisterAsNewUser: "Register as a new user",
            LastUpdated: "Last updated",
            ConfirmDelete: "Are you sure you want to delete this item ?",
            Navigation: {
                Home: "Home",
                Projects: "Projects",
                Employees: "Employees"
            },
            Commands: {
                Create: "Create New",
                Save: "Save",
                Delete: "Delete",
                BackToList: "Back to List"
            },
            Edit: {
                Title: "Edit"
            },
            Projects: {
                TitleList: "Project list",
                TitleCreate: "Add a project",
                TitleEdit: "Modify a project",
                Number: "#",
                Active: "Active",
                Customer: "Customer",
                Description: "Description",
                Time: "Time (hr)",
                Expenditures: "Expenditures",
                Search: "Search Projects..."
            },
            Employees: {
                TitleList: "Employee list",
                TitleCreate: "Add an employee",
                TitleEdit: "Modify an employee",
                Number: "#",
                Active: "Active",
                Innactive: "Innactive",
                FirstName: "First Name",
                LastName: "Last Name",
                Rate: "Rate",
                Mobile: "Mobile",
                Email: "Email",
                Search: "Search Employees..."
            }
        };
    }

    function getFrenchTranslations() {
        return {
            ApplicationTitle: "IEJP Gestion du temps",
            ForgotYourPassword: "Mot de passe oublié?",
            Login: "Connexion",
            RegisterAsNewUser: "S'enregistrer en tant que nouvel utilisateur",
            LastUpdated: "Modifié le",
            ConfirmDelete: "Voulez-vous supprimer cet item ?",
            Navigation: {
                Home: "Home",
                Projects: "Projects",
                Employees: "Employees"
            },
            Commands: {
                Create: "Ajouter",
                Save: "Enregistrer",
                Delete: "Suprimer",
                BackToList: "Retour à la liste"
            },
            Edit: {
                Title: "Modifier"
            },
            Projects: {
                TitleList: "Liste de projets",
                TitleCreate: "Ajouter un projets",
                TitleEdit: "Modifier un projets",
                Number: "No.",
                Active: "Actif",
                Customer: "Client",
                Description: "Description",
                Time: "Temp (hr)",
                Expenditures: "Dépenses",
                Search: "Filtrer les projets..."
            },
            Employees: {
                TitleList: "Liste des employés",
                TitleCreate: "Ajouter un employé",
                TitleEdit: "Modifier un employé",
                Number: "No.",
                Active: "Actif",
                Innactive: "Innactif",
                FirstName: "Prénom",
                LastName: "Nom",
                Rate: "Taux",
                Mobile: "Mobile",
                Email: "Courriel",
                Search: "Filtrer les employés..."
            }
        };
    }
})();