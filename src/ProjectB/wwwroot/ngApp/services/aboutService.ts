namespace ProjectB.Services {

    export class AboutService {
        public quoteResource;

        constructor(private $resource: angular.resource.IResourceService) {
            this.quoteResource = $resource('api/about');
        }

        getRandomQuote(id) {
            return this.quoteResource.getQuote({id: id});
        }
    }
    angular.module('ProjectB').service('aboutService', AboutService)
}