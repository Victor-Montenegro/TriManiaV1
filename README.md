# TriManiaV1
Projeto com a finalidade de praticar os conceitos de arquitetura limpa, CQRS, MediatR e EF.

# Passo a Passo
  Realize o clone do repositorio na sua maquina 
  
  Ao abrir o projeto no Visual Studio:
    Vá em SolutionExplorer 
    
  ![image](https://user-images.githubusercontent.com/56697589/160260118-216c2a65-3346-4549-a4e3-dadf2b8a69db.png)


Abra a pasta TriMania_V1 e clique duas vezes em TriMania_V1.sln
   ![image](https://user-images.githubusercontent.com/56697589/160260125-86bbb667-71d1-468f-8203-ba42d260f7a9.png)


No projeto TriMania_V1, clique com o botão direito e vá em properties
![image](https://user-images.githubusercontent.com/56697589/160260235-17773e86-57ac-4293-a37a-43be7cd10271.png)

   
Na categoria build -> Output path --> --> XML document file -> Desmarque e marque novamente para que o visual Studio pegue o caminho correto do seu repositorio para gerar o xml do swagger.
![image](https://user-images.githubusercontent.com/56697589/160260292-2b3664c9-c2bd-4292-aa1e-c1e5c3b2e52b.png)

Salve a alteração e realize o Rebuild Solution

![image](https://user-images.githubusercontent.com/56697589/160260354-20a1f449-85e0-4fbb-b8f2-18ad43a836a8.png)

Antes de executar os passos a a seguir para realizar a criação do banco de dados. Certifique-se se o serviço MySql está rodando, caso não esteja, coloque em execução

![image](https://user-images.githubusercontent.com/56697589/160260691-88024ddc-a9ee-4713-b148-c702e653144a.png)

Caso você não tenha o MySql instalado realize a instação atraves desse site: [MySQL](https://dev.mysql.com/downloads/mysql/)

No arquivo ContextFactory.cs | appsettings.json | BaseRepositoryDP.cs: altere a connectionString para o user e a senha do seu localhost configurado na instalação
![image](https://user-images.githubusercontent.com/56697589/160260823-b1e2ebf0-04d2-42ce-a724-963477117c92.png)
![image](https://user-images.githubusercontent.com/56697589/160261039-84dc8fbe-c2b8-4cf9-b0c8-d9cac763baf6.png)
![image](https://user-images.githubusercontent.com/56697589/160261051-4947f02f-4ab5-43f8-9dc6-28337375fdff.png)

No projeto Infrastructure clique com o botão direito e clique em : Set as Startup Project

![image](https://user-images.githubusercontent.com/56697589/160260534-19434bd7-014d-4a1e-91d6-991ea6d00483.png)

Em Tools --> NuGet Package Manager --> Package Manager Console

![image](https://user-images.githubusercontent.com/56697589/160260589-943c21af-c8c0-4098-baee-8d4fe5676595.png)


Selecione Infrastructure

![image](https://user-images.githubusercontent.com/56697589/160260606-4eb347fc-549a-4e00-adfb-4a2e09218715.png)


Coloque o comando a seguir e aperte enter:

    Update-Database

Resultado esperado: 
![image](https://user-images.githubusercontent.com/56697589/160260896-f127b857-5d6e-4a95-a260-3b320aeb8efc.png)

No projeto TriMania_V1 clique com o botão direito e selecione: Set as Startup Project
![image](https://user-images.githubusercontent.com/56697589/160260946-4fe84811-21a9-4e49-b8ae-29b74caab3ef.png)

Realize a alteração para TriMania_V1

![image](https://user-images.githubusercontent.com/56697589/160260984-e53f6f0f-25d0-4259-8c3f-794316f8f55d.png)

Aperte F5

Resultado esperado:
![image](https://user-images.githubusercontent.com/56697589/160261070-05d896c4-3532-482b-a078-13b549506819.png)

para realizar o login com o admin:

    {
      "login": "admin",
      "passworld": "123456"
    }


# FLUXO: USUÁRIO 
1. Sem realizar o login no sistema:
- Sem o usuário está logado, só poderá realizar duas ações:
  - Visualizar a lista de produtos que a loja oferece: **OBS: Caso a loja não tenha cadastrado nenhum produto,a lista estará vazia**
![image](https://user-images.githubusercontent.com/56697589/160296348-f905528c-8cd1-4771-9e83-de09f690e467.png)
       - Realizar a criação de um usuário.
       ![image](https://user-images.githubusercontent.com/56697589/160296877-83ae0fa7-bb79-469c-854a-56890ef08597.png)
       ![image](https://user-images.githubusercontent.com/56697589/160296886-942ed78f-8fd3-4447-99bf-6e5f72f5687c.png)

2. Realizando login no sistema:
![image](https://user-images.githubusercontent.com/56697589/160302935-20bbc852-4116-467a-bc8d-8e06f509f871.png)
- Para que o usuário possa realizar a criação de um pedido, ele deve logar no sistema
  - Login
      ![image](https://user-images.githubusercontent.com/56697589/160297244-2f709bb9-e106-4cd8-bc1c-593574a604f0.png)
  - Capture o token
      ![image](https://user-images.githubusercontent.com/56697589/160297271-40b32164-eef5-40f4-a291-0c2e374328d9.png)
  - Clique em authorize no canto superior direito
      ![image](https://user-images.githubusercontent.com/56697589/160297329-0aa8bdf7-e84b-45da-ae4d-29b414faca17.png)
  - Coloque **bearer** e logo em seguinda um espaço e o cole o token e aperte em Authorize
      ![image](https://user-images.githubusercontent.com/56697589/160297389-be976550-ad3f-4cf3-9c1d-dbff78be0faf.png)

3. Usuário logado no sistema:
- Com o usuário logado no sistema, ele poderá fazer todas as operações de criação, alteração, remoção de itens, cancelamento e completa/finalizar um pedido. Realizara visualização de seu usuário. 
![image](https://user-images.githubusercontent.com/56697589/160297589-0b4861ab-18ac-4e59-9ae0-d8b9b16e9589.png)
![image](https://user-images.githubusercontent.com/56697589/160305476-e446311b-7d07-43e0-88e7-28dc8f6e0194.png)

  - OBS: Caso o usuário faça quaisquer operação sem ter criado um pedido ou não tenha algum pedido em aberto será retornado:
  ![image](https://user-images.githubusercontent.com/56697589/160297714-f661ca7e-a666-403d-8215-d702554abaf7.png)

4. Visualizar o usuário | Criando | Alterando | Removendo Itens | Cancelando | Finalizando/Completando um pedido | Visualizando pedido.

- **Visualizar o usuário**
![image](https://user-images.githubusercontent.com/56697589/160305521-5982b2b7-0565-4119-81f4-df2851024ad2.png)
  - Realizar as informações do usuário que está logado.
![image](https://user-images.githubusercontent.com/56697589/160305545-47aec663-fd0a-4e73-9cc1-429937d59b12.png)

- **Criando um pedido**
![image](https://user-images.githubusercontent.com/56697589/160298944-520db4a5-68cb-4d62-8e20-4b93cdaed697.png)
  - Ao realizar a criação de um pedido, deve ser passado o Id do usuário, e as informações do produto como id do produto, qunatidade  e preço. **O pedido pode ter um ou mais itens**.
   - Retornará error se caso o produto não exista 
![image](https://user-images.githubusercontent.com/56697589/160298967-069ff1be-c7e0-455e-9131-faf7fe21767e.png)
   - Retornará error se caso o produto nao tenha estoque 
![image](https://user-images.githubusercontent.com/56697589/160299003-702d6791-cee7-434e-b385-54fcb26f759b.png)
   - Retornará error se caso informar dois produtos com o mesmo id
![image](https://user-images.githubusercontent.com/56697589/160302015-f6fbb974-631d-4936-a4be-b3e2efce20a1.png)
   - Caso o produto exista,tenha estoque e todas as informações necessárias do pedido foram colocadas o pedido será criado
![image](https://user-images.githubusercontent.com/56697589/160299126-c1d8df21-6287-4bd1-8b7b-11ce39bcec15.png)
   - Com o pedido criado, o usuário não poderá realizar a criação de outro pedido até finalizar o que está em aberto.
![image](https://user-images.githubusercontent.com/56697589/160299225-60e91497-8a13-4558-9a07-d363ce34a0fb.png)
- **Visualizando pedido**
![image](https://user-images.githubusercontent.com/56697589/160301548-3b735d8f-5971-43da-9f51-3602f4217959.png)
  - Para realizar a visualição do pedido, o usuário deve ter criado um pedido
![image](https://user-images.githubusercontent.com/56697589/160301642-aa6c39a5-2632-44b4-90d3-8692e3bac0d9.png)
  - Caso o usuário não tenha criado nenhum pedido ou não tenha pedidos com status 0(Completo) ou 1(Em pregresso) retornará uma mensagem:
 ![image](https://user-images.githubusercontent.com/56697589/160301735-1b91f4e6-e3a1-43da-8bd7-df07b16c3bb5.png)

- **Alterando pedido**
![image](https://user-images.githubusercontent.com/56697589/160299308-460215e2-5f75-4b78-9407-9656668796f2.png)
  - Para realizar a alteração do pedido, o usuário já deve ter feito a criação de um pedido.
    - Caso queria alterar um item no pedido, deve ser informado o id do produto que está no pedido e realizar a alteração da quantidade ou preço
![image](https://user-images.githubusercontent.com/56697589/160301876-3a4b809d-2212-4e05-9539-2b2155909e2f.png)
![image](https://user-images.githubusercontent.com/56697589/160301889-d5269e7b-ee50-4414-87c7-9b2ebc4211a7.png)
    - Caso queria adicionar um novo produto, basta informa um id de produto que não esteja no pedido
![image](https://user-images.githubusercontent.com/56697589/160301939-1525a6ba-0bbe-4cba-bf78-76dcf6103de6.png)
    - **OBS: Serão feitas as mesmas validações na hora de realizar a criação de um pedido**

- **Removendo um item do pedido**
![image](https://user-images.githubusercontent.com/56697589/160302100-e5bf03d8-aa29-4422-a6c9-041a3f787705.png)
  - Só poderá remover itens do pedido se caso o usuário tenha algum pedido já criado. para remover um ou mais item do pedido deve informa o id dos itens do pedido 
![image](https://user-images.githubusercontent.com/56697589/160302207-56724ba9-d8ce-4b7e-abac-8229b15b9a6e.png)
![image](https://user-images.githubusercontent.com/56697589/160302688-e85f5a81-ae52-45d4-8945-46612eb648af.png)
  - Caso o pedido tenha apenas um item de pedido, não será possível remover esse item
  ![image](https://user-images.githubusercontent.com/56697589/160302254-00f2110b-c9c3-42a8-badb-2e0f3f483a50.png)

- **Completando/Finalizando um pedido**
![image](https://user-images.githubusercontent.com/56697589/160302722-a75ed3ea-5416-4fca-85c1-7b8f7fc26fbb.png)
  - O usuário deve ter criado um pedido para finaliza-lo. Para finalizar um pedido, deve ser passado o farma de pagamento, 
    - Ao realizar a finalização de um pedido, será checado novamente se a estoque dos produtos, caso no mento da finalização o produto não tenha mais estoque, retorná:
![image](https://user-images.githubusercontent.com/56697589/160302818-59bdc4e9-0610-4f1b-86d4-b24c720b63b1.png)
    - Caso todos os produtos tenham estoque será finalizado a pedido e os estoques dos produtos serão atualizados nesse momento.
![image](https://user-images.githubusercontent.com/56697589/160302872-4000bdc3-ea52-40e4-8f8b-a1351ad6958c.png)


# FLUXO : ADMIN
1. Realizar o login com o ADMIN
![image](https://user-images.githubusercontent.com/56697589/160303143-ec6c1196-b43f-41c8-b23a-2a5635a00e01.png)

    {
      "Login" : "admin",
      "Passworld" : "123456"
    }

2. Com o admin logado, ele terá permissão de acessar: A lista de usuário através de um filtro | Visualizar relatorio da loja | Remover um usuário do sistema
- **Visualizar lista de usuário **
  - Para visualizar a lista de usuário deve ser passado o número da página e o filtro, onde o filtro pesquisará pelo email, login ou nome de um usuário. A lista será paginada em 10 em 10 usuários. 
![image](https://user-images.githubusercontent.com/56697589/160303621-d5b8358c-b494-47c7-9b04-4d613b6102cb.png)
![image](https://user-images.githubusercontent.com/56697589/160303694-edbbd3a1-183c-4715-9458-c326724298cd.png)
![image](https://user-images.githubusercontent.com/56697589/160303703-0563dc16-9535-4392-9bb2-c6d14df74856.png)

- **Visualizar relatorio da loja**
  - Relatorio da loja de todas os pedidos dos usuários, deverá ser passado os filtros necessários como a data inicial e final dos pedidos, passando um ou mais status dos pedidos e um ou mais usuários.
![image](https://user-images.githubusercontent.com/56697589/160305127-988cc208-642a-4f99-b671-5e82d42b7a27.png)
  - A data inicial deve ser menor do que a data final
 ![image](https://user-images.githubusercontent.com/56697589/160305160-29084d90-2ad1-4cf3-a9c4-9c51351c0645.png)
  - Deve ser passado ao menos um usuário ou ao menos um status      
![image](https://user-images.githubusercontent.com/56697589/160305189-8894453a-b59c-440f-945b-a24d47da4b6b.png)
![image](https://user-images.githubusercontent.com/56697589/160305202-790d44bc-a0e9-44c7-bf1b-69f5154b465c.png)

- **Remove um usuário do sistema**
![image](https://user-images.githubusercontent.com/56697589/160305246-ead05324-33f2-44aa-8c22-d38526ac31f8.png)
  - Para remover um usuário ele não deve ter nenhum pedido com status 0(completo) ou 1(em progresso)
![image](https://user-images.githubusercontent.com/56697589/160305294-b10099c4-44de-49f8-8c7a-ce9323b9fb4b.png)
  - Caso o usuário não tenha pedidos com os status 0 ou 1, será possível remover
![image](https://user-images.githubusercontent.com/56697589/160305330-c0b0b242-0353-482c-a223-137d2c05b6a7.png)

