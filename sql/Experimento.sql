select *
from RequisicaoEntrada (nolock) as e
LEFT join RequisicaoSaida (nolock) as s
on e.ID = s.ID
order by datahorainicio desc

select max(Duracao)
from RequisicaoEntrada (nolock) as e
LEFT join RequisicaoSaida (nolock) as s
on e.ID = s.ID
where ContainerName = 'alto' 

select max(Duracao)
from RequisicaoEntrada (nolock) as e
LEFT join RequisicaoSaida (nolock) as s
on e.ID = s.ID
where ContainerName = 'baixo' 

select count(1)
from RequisicaoEntrada (nolock) as e
LEFT join RequisicaoSaida (nolock) as s
on e.ID = s.ID
where s.DataHoraFim is null