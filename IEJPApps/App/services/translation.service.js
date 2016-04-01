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
            Totals: {
                Transaction: "transaction(s)",
                Items: "item(s)",
                Of: "of"
            },
            Navigation: {
                Home: "Home",
                Projects: "Projects",
                Employees: "Employees",
                TimeSheet: "Time Sheet",
                Expenditures: "Expenditures"
            },
            Commands: {
                Create: "Create New",
                Save: "Save",
                Delete: "Delete",
                BackToList: "Back to List",
                Filter: "Filter..."
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
            },
            TimeSheet: {
                TitleList: "Time sheet",
                TitleCreate: "Add a transaction",
                TitleEdit: "Modify a transaction",
                Day: "Day",
                Project: "Project",
                Employee: "Employee",
                Time: "Time",
                Comment: "Comment"
            },
            Expenditures: {
                TitleList: "Expenditure sheet",
                TitleCreate: "Add a transaction",
                TitleEdit: "Modify a transaction",
                Project: "Project",
                Employee: "Employee",
                Type: "Type",
                Amount: "Amount",
                Comment: "Comment"
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
            Totals: {
                Transaction: "transaction(s)",
                Items: "item(s)",
                Of: "de"
            },
            Navigation: {
                Home: "Home",
                Projects: "Projets",
                Employees: "Employés",
                TimeSheet: "Feuille de temps",
                Expenditures: "Dépenses"
            },
            Commands: {
                Create: "Ajouter",
                Save: "Enregistrer",
                Delete: "Suprimer",
                BackToList: "Retour à la liste",
                Filter: "Filtrer..."
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
                Expenditures: "Dépenses"
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
                Email: "Courriel"
            },
            TimeSheet: {
                TitleList: "Feuille de temps",
                TitleCreate: "Ajouter une transaction",
                TitleEdit: "Modifier une transaction",
                Day: "Jour",
                Project: "Projet",
                Employee: "Employé",
                Time: "Temps",
                Comment: "Commentaire"
            },
            Expenditures: {
                TitleList: "Compte de dépense",
                TitleCreate: "Ajouter une transaction",
                TitleEdit: "Modifier une transaction",
                Project: "Project",
                Employee: "Employé",
                Type: "Type",
                Amount: "Amount",
                Comment: "Comment"
            }
        };
    }
})();