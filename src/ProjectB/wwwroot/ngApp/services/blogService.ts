namespace ProjectB.Services {

    export class BlogService {
        private blogResource;

        constructor(private $resources: angular.resource.IResourceService) {
            this.blogResource = this.$resources('/api/blog/:category');
        }

        //create
        public saveBlog(blogToSave) {
            return this.blogResource.save(blogToSave).$promise;
        }

        //read
        public getBlog() {
            return this.blogResource.query().$promise;
        }

        //specific blog id
        public getBlogById(id) {
            return this.blogResource.get({ id: id })
        }

        //delete
        public deleteBlog(id) {
            return this.blogResource.delete({ id: id }).$promise;
        }
    }
    angular.module('ProjectB').service('BlogService', BlogService);
}

