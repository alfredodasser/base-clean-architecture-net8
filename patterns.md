

CREACIONALES:

“Implementa el patrón Singleton en una clase SystemConfiguration para gestionar configuración global (por ejemplo: StoreName, DefaultCurrency).”

“Crea una clase BookFactory con un método CreateBook(string type) que devuelva instancias de clases derivadas (PhysicalBook, DigitalBook, SpecialEditionBook).”
UBicarlo en: src/Domain/Factories/

“Implementa un patrón Builder llamado OrderBuilder que permita construir un objeto Order agregando cliente, ítems y descuentos con métodos encadenados.”
Ubicarlo en: src/Domain/Builders/

ESTRUCTURALES:

“Crea un patrón Adapter para integrar un servicio externo de pagos (ExternalStripePayment) con una interfaz interna IPaymentService usando una clase adaptadora StripePaymentAdapter.”
Ubicarlo en: src/Infrastructure/Payments/Adapters/

Decorator
“Implementa el patrón Decorator para aplicar múltiples descuentos sobre un pedido. Usa una clase base BaseDiscount y decoradores concretos como LoyalCustomerDiscount y PromotionDiscount.”
Ubicarlo en: src/Domain/Discounts/

Facade
“Crea una clase BookStoreFacade que encapsule operaciones de creación de pedidos, cálculo de descuentos y procesamiento de pagos en un único punto de acceso.”
Ubicarlo en: src/Application/Facades/

COMPORTAMIENTO:

Observer
“Implementa el patrón Observer donde OrderNotifier mantiene una lista de observadores (IOrderObserver) y los notifica cuando cambia el estado de un pedido.”
Ubicarlo en: src/Domain/Events/

Strategy
“Crea una interfaz IDiscountStrategy y varias implementaciones concretas para calcular descuentos según el tipo de cliente.”
Ubicarlo en: src/Domain/Strategies/


Template Method:
“Implementa el patrón Template Method con una clase abstracta ReportTemplate que defina el método Generate() con pasos fijos y específicos en subclases
Ubicarlo en: src/Application/Reports/

Crear los casos de uso (Application Layer):

“Crea un conjunto de comandos para manejar la creación, pago y notificación de pedidos siguiendo el patrón CQRS. Cada comando debe llamar a los servicios o patrones implementados en la capa Domain e Infrastructure.”
Ubicarlo en: src/Application/Orders/Commands/


CONTROLLER:

Integración desde la capa WebAPI:

Ubicación: src/WebApi/Controllers/OrdersCStripePaymentAdapterontroller.cs

“Crea un controlador OrdersController con un endpoint POST /api/orders que:
1-Construya un pedido con OrderBuilder.
2-Aplique una estrategia de descuento (IDiscountStrategy).
3-Procese el pago usando StripePaymentAdapter.
4-Notifique a observadores (OrderNotifier).
5-Devuelva un resumen del pedido creado.”

-----
Integración con BookStoreFacade

“Usa la clase BookStoreFacade para encapsular todo el flujo de creación, pago y notificación de pedidos dentro del OrdersController. Refactoriza el código para que sea más limpio y mantenible.”

-----
Validar principios SOLID y refactorizar con Copilot Chat