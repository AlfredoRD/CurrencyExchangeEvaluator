# CurrencyExchangeEvaluator

> Proyecto técnico: Comparador de ofertas de tipo de cambio para clientes bancarios.

Este proyecto simula la consulta de múltiples APIs de tipo de cambio para encontrar la mejor oferta de conversión de divisas. La lógica compara las respuestas y selecciona la que devuelve el monto más alto.

---

## 🧠 Objetivo

Dado un conjunto de datos de entrada:
- Moneda origen (`source currency`)
- Moneda destino (`target currency`)
- Monto a convertir

El sistema debe consultar múltiples APIs simuladas y seleccionar la oferta que más beneficiosa sea para el cliente.

---

## 📦 Estructura del proyecto

```bash
CurrencyExchangeEvaluator/
├── Application/        # Lógica de negocio y comparación
├── Domain/             # Modelos de datos
├── Infrastructure/     # Implementaciones simuladas de APIs
└── Program.cs          # Entrada del programa
