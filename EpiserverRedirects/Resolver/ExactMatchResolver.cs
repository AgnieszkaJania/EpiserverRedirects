﻿using System;
using System.Linq;
using System.Threading.Tasks;
using EPiServer;
using Forte.EpiserverRedirects.Model;
using Forte.EpiserverRedirects.Model.RedirectRule;
using Forte.EpiserverRedirects.Redirect;
using Forte.EpiserverRedirects.Repository;
using SiteDefinition = EPiServer.Web.SiteDefinition;

namespace Forte.EpiserverRedirects.Resolver
{
    public class ExactMatchResolver : BaseRuleResolver, IRedirectRuleResolver
    {
        private readonly IRedirectRuleRepository _redirectRuleResolverRepository;

        public ExactMatchResolver(IRedirectRuleRepository redirectRuleResolverRepository, IContentLoader contentLoader) : base(contentLoader)
        {
            _redirectRuleResolverRepository = redirectRuleResolverRepository;
        }

        public Task<IRedirect> ResolveRedirectRuleAsync(UrlPath oldPath)
        {
            var currentSite = SiteDefinition.Current;
            var encodedOldPath = Uri.EscapeUriString(oldPath.ToString());
            var rule = _redirectRuleResolverRepository
                .GetAll()
                .Where(r => r.HostId == null || r.HostId == currentSite.Id)
                .Where(r => r.IsActive && r.RedirectRuleType == RedirectRuleType.ExactMatch && r.OldPattern == encodedOldPath)
                .OrderBy(x => x.Priority)
                .AsEnumerable()
                .FirstOrDefault();

            var result = ResolveRule(rule, r => new ExactMatchRedirect(r));
            return Task.FromResult(result);
        }
    }
}
