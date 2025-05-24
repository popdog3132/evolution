#!/usr/bin/env bash
set -e

cd "$(dirname "$0")"

python -m venv .venv
source .venv/bin/activate

python -m pip install --upgrade pip

pip install torch==2.3.0+cu122 torchvision --index-url https://download.pytorch.org/whl/cu122
pip install transformers==4.42.0 datasets accelerate deepspeed flash-attn==2.5.2 bitsandbytes==0.43 peft==0.10

python scripts/prepare_dataset.py --hf_id yahma/alpaca-cleaned --hf_id databricks/databricks-dolly-15k --out_dir data/instruct --max_samples 65000

echo "Environment ready 🎉"
