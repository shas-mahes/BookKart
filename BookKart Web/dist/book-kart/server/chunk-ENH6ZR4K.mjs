import './polyfills.server.mjs';
import{a as S,b as I,c as P,f as N,l as E}from"./chunk-3AH6TJXI.mjs";import{G as f,H as g,M as y,Ma as D,P as a,Qa as M,R as v,ca as C,ia as A,ja as b,ka as w,ma as x,na as F,sa as m,ta as c,ua as R,va as l,wa as d}from"./chunk-KWENV4TC.mjs";var T=(()=>{let e=class e{};e.\u0275fac=function(o){return new(o||e)},e.\u0275cmp=a({type:e,selectors:[["app-home"]],standalone:!0,features:[d],decls:2,vars:0,template:function(o,i){o&1&&(m(0,"p"),l(1,"home works!"),c())}});let n=e;return n})();var O=(()=>{let e=class e{};e.\u0275fac=function(o){return new(o||e)},e.\u0275cmp=a({type:e,selectors:[["app-nav-bar"]],standalone:!0,features:[d],decls:2,vars:0,template:function(o,i){o&1&&(m(0,"p"),l(1,"nav-bar works!"),c())}});let n=e;return n})();var k=(()=>{let e=class e{constructor(){this.title="BookKart"}};e.\u0275fac=function(o){return new(o||e)},e.\u0275cmp=a({type:e,selectors:[["app-root"]],standalone:!0,features:[d],decls:3,vars:0,template:function(o,i){o&1&&(l(0,","),R(1,"app-nav-bar")(2,"app-home"))},dependencies:[T,O]});let n=e;return n})();var B=[];var U="@",K=(()=>{let e=class e{constructor(r,o,i,s,p){this.doc=r,this.delegate=o,this.zone=i,this.animationType=s,this.moduleImpl=p,this._rendererFactoryPromise=null,this.scheduler=y(b,{optional:!0})}ngOnDestroy(){this._engine?.flush()}loadImpl(){return(this.moduleImpl??import("./chunk-ZS3Z57RT.mjs")).catch(o=>{throw new f(5300,!1)}).then(({\u0275createEngine:o,\u0275AnimationRendererFactory:i})=>{this._engine=o(this.animationType,this.doc,this.scheduler);let s=new i(this.delegate,this._engine,this.zone);return this.delegate=s,s})}createRenderer(r,o){let i=this.delegate.createRenderer(r,o);if(i.\u0275type===0)return i;typeof i.throwOnSyntheticProps=="boolean"&&(i.throwOnSyntheticProps=!1);let s=new u(i);return o?.data?.animation&&!this._rendererFactoryPromise&&(this._rendererFactoryPromise=this.loadImpl()),this._rendererFactoryPromise?.then(p=>{let H=p.createRenderer(r,o);s.use(H)}).catch(p=>{s.use(i)}),s}begin(){this.delegate.begin?.()}end(){this.delegate.end?.()}whenRenderingDone(){return this.delegate.whenRenderingDone?.()??Promise.resolve()}};e.\u0275fac=function(o){A()},e.\u0275prov=g({token:e,factory:e.\u0275fac});let n=e;return n})(),u=class{constructor(e){this.delegate=e,this.replay=[],this.\u0275type=1}use(e){if(this.delegate=e,this.replay!==null){for(let t of this.replay)t(e);this.replay=null}}get data(){return this.delegate.data}destroy(){this.replay=null,this.delegate.destroy()}createElement(e,t){return this.delegate.createElement(e,t)}createComment(e){return this.delegate.createComment(e)}createText(e){return this.delegate.createText(e)}get destroyNode(){return this.delegate.destroyNode}appendChild(e,t){this.delegate.appendChild(e,t)}insertBefore(e,t,r,o){this.delegate.insertBefore(e,t,r,o)}removeChild(e,t,r){this.delegate.removeChild(e,t,r)}selectRootElement(e,t){return this.delegate.selectRootElement(e,t)}parentNode(e){return this.delegate.parentNode(e)}nextSibling(e){return this.delegate.nextSibling(e)}setAttribute(e,t,r,o){this.delegate.setAttribute(e,t,r,o)}removeAttribute(e,t,r){this.delegate.removeAttribute(e,t,r)}addClass(e,t){this.delegate.addClass(e,t)}removeClass(e,t){this.delegate.removeClass(e,t)}setStyle(e,t,r,o){this.delegate.setStyle(e,t,r,o)}removeStyle(e,t,r){this.delegate.removeStyle(e,t,r)}setProperty(e,t,r){this.shouldReplay(t)&&this.replay.push(o=>o.setProperty(e,t,r)),this.delegate.setProperty(e,t,r)}setValue(e,t){this.delegate.setValue(e,t)}listen(e,t,r){return this.shouldReplay(t)&&this.replay.push(o=>o.listen(e,t,r)),this.delegate.listen(e,t,r)}shouldReplay(e){return this.replay!==null&&e.startsWith(U)}};function j(n="animations"){return x("NgAsyncAnimations"),v([{provide:w,useFactory:(e,t,r)=>new K(e,t,r,n),deps:[M,S,F]},{provide:C,useValue:n==="noop"?"NoopAnimations":"BrowserAnimations"}])}var V={providers:[E(B),P(),j()]};var L={providers:[N()]},z=D(V,L);var W=()=>I(k,z),ue=W;export{ue as a};
