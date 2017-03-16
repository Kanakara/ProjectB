namespace ProjectB.Controllers {

    export class BlogController {
        public blogs

        constructor(private blogService: ProjectB.Services.BlogService,
            private $uibModal: angular.ui.bootstrap.IModalService) {
            this.getBlog();
        }

        public getBlog() {
            this.blogs = this.blogService.getBlog();
        } 

        //Blog Delete Modal 
        showDeleteModal(blogId: number) {
            this.$uibModal.open({
                templateUrl: "/ngApp/views/blogDelete.html",
                controller: ProjectB.Controllers.BlogDeleteController,
                controllerAs: "controller",
                resolve: { blogId: () => blogId },
                size: "sm"
            }).closed.then(() => {
                this.getBlog();
            });
        }


    }
}
