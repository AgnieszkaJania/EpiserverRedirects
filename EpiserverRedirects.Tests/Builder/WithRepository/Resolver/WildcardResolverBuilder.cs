using Forte.EpiserverRedirects.Resolver;

namespace Forte.EpiserverRedirects.Tests.Builder.WithRepository.Resolver
{
    public class WildcardResolverBuilder : BaseWithRepositoryBuilder<WildcardResolver, WildcardResolverBuilder>
    {
        protected override WildcardResolverBuilder ThisBuilder => this;

        public override WildcardResolver Create()
        {
            CreateRepository();
            return new WildcardResolver(RedirectRuleRepository);
        }
    }
}