import{i as P,A as o,j as w,l as p,_ as S,u as V,b as I,d,r as u,o as c,c as n,a as t,e as _,F as f,f as v,P as g,v as K,k as U,p as B,h as C}from"./index-268f8f50.js";class x{async getProfileById(l){const i=await P.get(`api/profiles/${l}`);o.profile=new w(i.data),p.log(o.profile)}}const A=new x;const F={setup(){const e=V();async function l(){try{await A.getProfileById(e.params.id)}catch(s){g.error("error getting profile"),p.log(s)}}async function i(){try{await K.getUserVaults(e.params.id)}catch(s){g.error("couldnt get user vaults",s),p.log(s)}}async function r(){try{o.page="profile",await U.getUserKeeps(e.params.id)}catch(s){g.error("error getting user keeps"),p.log(s)}}return I(()=>{l(),i(),r()}),{profile:d(()=>o.profile),vaults:d(()=>o.vaults),keeps:d(()=>o.userKeeps)}}},h=e=>(B("data-v-de9d9815"),e=e(),C(),e),H={class:"container"},N={class:"container"},$={class:"row"},b=h(()=>t("h1",null,"Vaults",-1)),j={class:""},E=h(()=>t("h1",null,"Keeps",-1)),L={class:"keep-container"};function M(e,l,i,r,s,R){const m=u("UserHero"),y=u("VaultCard"),k=u("KeepCard");return c(),n(f,null,[t("header",H,[_(m,{account:r.profile},null,8,["account"])]),t("main",N,[t("section",$,[b,(c(!0),n(f,null,v(r.vaults,a=>(c(),n("div",{class:"col-6 col-lg-3",key:a.id},[_(y,{vault:a},null,8,["vault"])]))),128))]),t("section",j,[E,t("div",L,[(c(!0),n(f,null,v(r.keeps,a=>(c(),n("div",{class:"",key:a.id},[_(k,{keep:a},null,8,["keep"])]))),128))])])])],64)}const z=S(F,[["render",M],["__scopeId","data-v-de9d9815"]]);export{z as default};
