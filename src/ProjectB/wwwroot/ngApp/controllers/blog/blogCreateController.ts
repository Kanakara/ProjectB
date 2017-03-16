namespace ProjectB.Controllers {

    export class BlogCreateController {
        public blogToSave = {};
        public user


        constructor(private blogService: ProjectB.Services.BlogService,
            private $state: angular.ui.IStateService,
            private accountService: ProjectB.Services.AccountService) {
            //this.user = this.isLoggedIn();

        }

        //public isLoggedIn() {
        //    return this.accountService.isLoggedIn();
        //}

        public saveBlog() {
            this.blogService.saveBlog(this.blogToSave).then(() => {
                this.$state.go('blog');
            });
            if (!this.user) {
            }
        }
    }
    angular.module("ProjectB").controller('blogCreateController', BlogCreateController);
}
