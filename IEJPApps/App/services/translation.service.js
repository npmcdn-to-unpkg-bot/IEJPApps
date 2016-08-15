(function () {
    'use strict';

    angular
        .module('app')
        .config(['$translateProvider', function ($translateProvider) {
            $translateProvider.translations('en', getEnglishTranslations());
            $translateProvider.translations('fr', getFrenchTranslations());
            $translateProvider.preferredLanguage('fr');
        }]);

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
                Manage: "Manage",
                Culture: "Language",
                Administration: "Administration",
                Projects: "Projects",
                Employees: "Employees",
                Periods: "Pay Periods",
                TimeSheet: "Time Sheet",
                Expenditures: "Expenditures",
                ExpenditureTypes: "Expenditure Types"
            },
            Commands: {
                Create: "Create New",
                Save: "Save",
                Delete: "Delete",
                BackToList: "Back to List",
                Filter: "Filter..."
            },
            Errors: {
                Error: 'Error',
                ErrorOccuredCancelled: "An error as occured. Operation was cancelled."
            },
            States: {
                Label: "State(s)",
                Active: "Active",
                Visible: "Visible",
                Current: "Current",
                Opened: "Opened",
                Closed: "Closed"
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
                Expenditures: "Expenditures"
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
                Email: "Email"
            },
            Periods: {
                TitleList: "Periods",
                TitleCreate: "Add a Period",
                TitleEdit: "Modify a Period",
                Period: "Period",
                StartDate: "Start Day",
                EndDate: "End Day",
                OpenedDate: "Opened Date",
                ClosedDate: "Closed Date",
                WeekNumber: "Week Number",
                Status: "Status"
            },
            TimeSheet: {
                TitleList: "Time sheet",
                TitleCreate: "Add a transaction",
                TitleEdit: "Modify a transaction",
                Day: "Day",
                Customer: "Customer",
                Project: "Project",
                Employee: "Employee",
                Time: "Time",
                Comment: "Comment"
            },
            Expenditures: {
                TitleList: "Expenditure sheet",
                TitleCreate: "Add expenditure",
                TitleEdit: "Modify expenditure",
                Date: "Date",
                Project: "Project",
                Customer: "Customer",
                Employee: "Employee",
                ExpenditureType: "Type",
                Amount: "Amount",
                Comment: "Comment"
            },
            ExpenditureTypes: {
                TitleList: "Expenditure Types",
                TitleCreate: "Add",
                TitleEdit: "Modify",
                Name: "Name",
                Description: "Description"                
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
                Manage: "Gestion",
                Culture: "Langue",
                Administration: "Administration",
                Projects: "Projets",
                Employees: "Employés",
                Periods: "Périodes de paie",
                TimeSheet: "Feuille de temps",
                Expenditures: "Dépenses",
                ExpenditureTypes: "Types de dépense"
            },
            Commands: {
                Create: "Ajouter",
                Save: "Enregistrer",
                Delete: "Suprimer",
                BackToList: "Retour à la liste",
                Filter: "Filtrer..."
            },
            Errors: {
                Error: 'Erreur',
                ErrorOccuredCancelled: "Une erreur est survenue. L'opération a été annullée."
            },
            States: {
                Label: "État(s)",
                Active: "Actif",
                Visible: "Visible",
                Current: "Courant(e)",
                Opened: "Ouvert(e)",
                Closed: "Fermé(e)"
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
            Periods: {
                TitleList: "Périodes de paie",
                TitleCreate: "Ajouter une période",
                TitleEdit: "Modifier une période",
                Period: "Période",
                StartDate: "Date de début",
                EndDate: "Date de fin",
                OpenedDate: "Date d'ouverture",
                ClosedDate: "Date de fermeture",
                WeekNumber: "Semaine",
                Status: "Statut"
            },
            TimeSheet: {
                TitleList: "Feuille de temps",
                TitleCreate: "Ajouter une transaction",
                TitleEdit: "Modifier une transaction",
                Day: "Jour",
                Customer: "Client",
                Project: "Projet",
                Employee: "Employé",
                Time: "Temps",
                Comment: "Commentaire"
            },
            Expenditures: {
                TitleList: "Compte de dépense",
                TitleCreate: "Ajouter une dépense",
                TitleEdit: "Modifier une dépense",
                Date: "Date",
                Project: "Projet",
                Customer: "Client",
                Employee: "Employé",
                ExpenditureType: "Type",
                Amount: "Montant",
                Comment: "Commentaire"
            },
            ExpenditureTypes: {
                TitleList: "Types de dépense",
                TitleCreate: "Ajouter un type de dépense",
                TitleEdit: "Modifier un type de dépense",
                Name: "Nom",
                Description: "Description"
            }
        };
    }
})();