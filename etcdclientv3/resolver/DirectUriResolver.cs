
namespace resolverv
{
    public class DirectUriResolver: IURIResolver
    {

        private static  List<String> SCHEMES = Arrays.asList("http", "https");

        private ConcurrentMap<URI, List<SocketAddress>> cache;

        DirectUriResolver() {
            this.cache = new ConcurrentHashMap<>();
        }

       
      public int priority() {
            return Integer.MIN_VALUE;
        }

    
      public bool supports(URI uri) {
            if (!SCHEMES.contains(uri.getScheme())) {
                return false;
            }

            if (!Strings.isNullOrEmpty(uri.getPath())) {
                return false;
            }

            if (uri.getPort() == -1) {
                return false;
            }

            return true;
        }

       
      public List<SocketAddress> resolve(URI uri) {
            if (!supports(uri)) {
                // Wrap as etcd exception but set a proper cause
                throw EtcdExceptionFactory.newEtcdException(
                    ErrorCode.INVALID_ARGUMENT,
                    "Unsupported URI " + uri
                );
            }

            return this.cache.computeIfAbsent(
                uri,
                u->Collections.singletonList(new InetSocketAddress(uri.getHost(), uri.getPort()))
            );
        }
    }
}
