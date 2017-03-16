namespace ProjectB.Controllers {

    export class BlogDeleteController {

        public blogToDelete;
        private blogId

        constructor(private blogService: ProjectB.Services.BlogService,
            private $state: angular.ui.IStateService,
            private $stateParams: angular.ui.IStateParamsService,
            private accountService: ProjectB.Services.AccountService,
            private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance) {
            this.blogId = this.$stateParams['blogId'];
            this.getBlogId();
        }

        public isLoggedIn() {
            return this.accountService.isLoggedIn();
        }
        public getBlogId() {
            this.blogToDelete = this.blogService.getBlogById(this.blogId);
        }

        public deleteBlog() {
            this.blogService.deleteBlog(this.blogId)
                .then(() => {
                    this.$state.reload();
                    this.$uibModalInstance.close();
                })
        }
        //cancel delete - exit modal<html>
        public cancel() {
            this.$uibModalInstance.close();
        }
    }
}
