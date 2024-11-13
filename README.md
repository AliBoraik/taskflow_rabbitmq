# TaskFlow RabbitMQ Integration

This repository provides a simple RabbitMQ integration within a background worker framework using C#. The project focuses on sending and receiving messages via RabbitMQ using a producer-consumer model. The solution involves two core components: **Producer** for sending messages and **Consumer** for receiving them.

## Project Overview

1. **Producer (RabbitMqProducer)**: Sends messages to a specific RabbitMQ queue.
2. **Consumer (ConsumerWorker)**: Listens for messages from a RabbitMQ queue and processes them.
3. **API Controller**: Exposes an endpoint to trigger sending a message via RabbitMQ.

## Getting Started

### Prerequisites

- **Docker** (with `docker compose`)
- **.NET SDK** (Version 7) *(optional, only for development or debugging)*

### Docker Setup for RabbitMQ

The project uses `docker compose` to start RabbitMQ and the application.

### Clone the Repository

Clone this repository to your local machine:

```bash
git clone https://github.com/your-username/taskflow-rabbitmq.git
cd taskflow-rabbitmq
docker compose up
